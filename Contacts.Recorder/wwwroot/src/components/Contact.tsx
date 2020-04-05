import * as React from "react";
import * as $  from 'jquery';
import { useState, useEffect } from "react";
import './style.css';
import {ContactDialog, IContact} from "./FormPopup";



function RetriveContact() 
{ 

   const [Contacts, setContacts] = useState<IContact[]>([]);
  

    useEffect(() => {
        // Update the document title using the browser API
        getAllContacts();
      },[]);


    const getAllContacts=()=>{
        $.getJSON( "Home/GetContacts", function(contacts:IContact[]) {
          setContacts(contacts)
          });
    }

    const save=(props:IContact)=>
    {
         $.post( "Home/Save",{...props})
            .done(function(data) {
              // if(props.id==null || props.id==""){
              //   setContacts(oldArray => [...Contacts, data]);
              // }
              // else
              // {
              //   const index = Contacts.findIndex((f: IContact) => f.id === data.id);
              //   setContacts([...Contacts.slice(0, index), data, ...Contacts.slice(index + 1)]);
              // }
              getAllContacts();
            });
    }

    const contact:IContact=
    {
      firstName:"",home:"",lastName:"",mobile:""
    }

    return (
        <div>
         
        <ContactDialog save={save} contactDetail={contact} />
              
        <div className="grid-container">
              <div><h5>Contact Id</h5></div>
              <div><h5>First Name</h5></div>
              <div><h5>Last Name</h5></div>
              <div><h5>Mobile</h5></div>
              <div><h5>Home</h5></div>
         </div>

          {Contacts.map((contact) =>
         <div className="grid-container">
            
              <div><ContactDialog save={save} contactDetail={contact} /></div>
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