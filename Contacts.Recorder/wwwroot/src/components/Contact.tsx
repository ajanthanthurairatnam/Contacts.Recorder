import * as React from "react";
import * as $  from 'jquery';
import { useState, useEffect } from "react";
import './style.css';



function Example1() {
  // Declare a new state variable, which we'll call "count"
  const [count, setCount] = useState(0);

  return (
    <div>
      <p>You clicked {count} times</p>
      <button onClick={() => setCount(count + 1)}>
        Click me
      </button>
    </div>
  );
}

function RetriveContact() 
{ 

   const [Contacts, setContact] = useState([]);

    useEffect(() => {
        // Update the document title using the browser API
        getAllContacts();
      },[]);


    const getAllContacts=()=>{
        $.getJSON( "Home/GetContacts", function(data:any) {
           setContact(data)
          });
    }

    const addContact=()=>
    {
         $.post( "Home/Add", { FirstName: "John", LastName: "Dalton",Mobile:"232323",Home:"2332123" })
            .done(function(data) {
                setContact(oldArray => [...Contacts, data]);
            });
    }

    return (
        <div>
            <button onClick={()=>addContact()}>
                Add
            </button>
        <div className="grid-container">
              <div><h5>First Name</h5></div>
              <div><h5>Last Name</h5></div>
              <div><h5>Mobile</h5></div>
              <div><h5>Home</h5></div>
         </div>

          {Contacts.map((contact) =>
         <div className="grid-container">
              <div>{contact.firstName}</div>
              <div>{contact.lastName}</div>
              <div>{contact.mobile}</div>
              <div>{contact.home}</div>
         </div>
          )}
        </div>
      );
}


export function Contact() {
    return (
        <div>
         <RetriveContact />
        </div>
    );
}