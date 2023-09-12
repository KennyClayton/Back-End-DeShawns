import React, { useEffect, useState } from "react";
import { getDogs, getGreeting } from "./apiManager";

export default function Home() {
  const [greeting, setGreeting] = useState("Not Connected to the API");
  const [dogs, setDogs] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        const greetingResponse = await getGreeting();
        setGreeting(greetingResponse.message);

        const dogResponse = await getDogs();
        setDogs(dogResponse);
      } catch (error) {
        console.log("API not connected", error);
      }
    }

    fetchData();
  }, []);

  return (
    <div>
      <h1>{greeting}</h1>
      <ul>
        {dogs.map((dog, index) => (
          <li key={index}>{dog.name}</li>
        ))}
      </ul>
    </div>
  );
}

// Old code below
  //   getGreeting()
  //     .then(setGreeting)
  //     .catch(() => {
  //       console.log("API not connected");
  //     });
  //    // Fetch list of dogs from your database
  //    getDogs()
  //    .then((response) => {
  //     return response.json();
  //    })
  //    .then((result) => {
  //      setDogs(result);
  //    })
  //    .catch(() => {
  //      console.log("Error fetching dogs from the API");
  //    });
  // }, []);



