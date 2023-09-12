import React from "react";

function DogDetail({ dog }) {
  return (
    <div>
      <h2>Dog Details</h2>
      <p>Name: {dog.Name}</p>
      <p>Walker: {dog.Walker || "No assigned walker"}</p>
      <p>City: {dog.cityId}</p>
    </div>
  );
}

export default DogDetail;
