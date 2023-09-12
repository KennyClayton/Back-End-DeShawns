export const getGreeting = async () => {
  const res = await fetch("/api/hello");
  return res.json();
};


//export a function that will get all dogs from the API
export const getDogs = async () => {
  const res = await fetch("/api/dogs");  
  return res.json();
};

// //? So we still need an empty order builder object to catch the input from the user?
// export const database = {
//   orderBuilder: {},
// };

// //? need to remember what this does...
// export const getCurrentState = async () => {
//   return database.orderBuilder;
// };

// //? need to remember what this does...
// export const getCurrentOrder = () => {
//   return database.orderBuilder;
// };

// export const setDog = (id) => {
//   database.orderBuilder.dogId = id;
//   // document.dispatchEvent(new CustomEvent("stateChanged"))
// };

// //? Review this function
// export const addCustomOrder = async () => {
//   const newOrder = { ...database.orderBuilder };
//   await fetch(`https://localhost:7268/api/orders`, {
//     method: "POST",
//     headers: {
//       "Content-Type": "application/json",
//     },
//     body: JSON.stringify(newOrder),
//   });
//   database.orderBuilder = {};
//   document.dispatchEvent(new CustomEvent("stateChanged"));
// };

// //? Review this function
// export const completeOrder = async (orderId) => {
//   await fetch(`https://localhost:7268/api/orders/${orderId}/fulfill`, {
//     method: "POST",
//   });
//   document.dispatchEvent(new CustomEvent("stateChanged"));
// };