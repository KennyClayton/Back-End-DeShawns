import React, { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router";

export const DogDetails = () => {
  const { id } = useParams(); // useParams will grab the id of the dog the user navigated to in the browser. This "id" parameter here must match whatever we called it in our route from the index.js component where we defined our routes


  const [dogDetails, setDogDetails] = useState({});
  const navigate = useNavigate();

  //the reason I am using a useEffect to fetch this data instead of just a function is because the url will be different each time. So we need to watch that id every time a click happens to see if the id changes to another dog id. That is what routes us to the proper dog page.
  useEffect(() => {
    fetch(`/api/dogs/${id}`)
      .then((res) => res.json())
      .then((selectedDog) => {
        setDogDetails(selectedDog); //and now we pass that dog object to dogDetails
      });
  }, [id]); // this tells the useEffect to run each time the dogId changes (ie, each time the url changes to a different endpoint)

  return (
    <div>
      <h2>Dog Details</h2>
      <p>{id}</p>
      <p>Name: {dogDetails.name}</p>
      <p>Walker: {dogDetails.walker?.name || "No assigned walker"}</p>
      <p>City: {dogDetails.city?.name}</p>
    </div>
  );
};

//use params to get id of that dog
//fetch the dog
//save it as a state variable

