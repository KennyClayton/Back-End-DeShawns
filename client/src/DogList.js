import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getDogs } from "./apiManager";



export function DogList() {
    //useEffect to get dogs and update the state of the dogs list/array
    const [dogs, setDogs] = useState([]);  
  
    useEffect(() => { // useEffect will get the list of dogs, then parse those objects into JSON
      getDogs() //this will get the list of dog objects from the database, which gets it from the API 
      .then((response) => response.json()) // convert the JSON data from the API response into JavaScript objects
      .then((result) => { // then take the dog objects and run the setDogs function, passing the dog objects (result) as an argument to update the dogs variable
        setDogs(result); //the dogs variable now is updated to the list of dogs
      });
       
    }, []); //we pass no parameters because we just want this useEffect to mount once and give us the list of dogs from the API
  
    //return jsx to list the dogs
    // return (
    //   <div>
    //     <h1>List of Dogs</h1>
    //     <ul>
    //     {dogs.map((dog) => (
    //       <li key={dog.id}>
    //         {/* Link to the DogDetail route with the selected dog's data */}
    //         <Link to={`/dogs/${dog.id}`}>{dog.name}</Link>
    //         </li>
    //     ))}
    //     </ul>
    //   </div>
    // );
  }