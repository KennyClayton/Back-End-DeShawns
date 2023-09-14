//^ The Home component will hold the jsx for rendering our text/headers and our list of dogs

import React, { useEffect, useState } from "react";
import { getDogs, getGreeting } from "./apiManager";
import { Link } from "react-router-dom";

export default function Home() {
  const [greeting, setGreeting] = useState("Not Connected to the API");
  const [dogs, setDogs] = useState([]);
  const [walkers, setWalkers] = useState([]);

//^ The Home component will hold the jsx for rendering our text/headers and our list of dogs

// The useEffect is for inital data load
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
          <ul key={index}>
            <Link to={`/dogs/${dog.id}`}>{dog.name}</Link>
          </ul>          
        ))}
      </ul>
      <article>
          <button id="addDogButton">Add Dog</button>
      </article>
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
