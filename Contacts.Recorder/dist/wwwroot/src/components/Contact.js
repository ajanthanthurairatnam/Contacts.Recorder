"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const $ = require("jquery");
const react_1 = require("react");
require("./style.css");
function Example1() {
    // Declare a new state variable, which we'll call "count"
    const [count, setCount] = react_1.useState(0);
    return (React.createElement("div", null,
        React.createElement("p", null,
            "You clicked ",
            count,
            " times"),
        React.createElement("button", { onClick: () => setCount(count + 1) }, "Click me")));
}
function RetriveContact() {
    const [Contacts, setContact] = react_1.useState([]);
    react_1.useEffect(() => {
        // Update the document title using the browser API
        getAllContacts();
    }, []);
    const getAllContacts = () => {
        $.getJSON("Home/GetContacts", function (data) {
            setContact(data);
        });
    };
    return (React.createElement("div", null, Contacts.map((contact) => React.createElement("div", { className: "grid-container" },
        React.createElement("div", { className: "flex-item" }, contact.firstName),
        React.createElement("div", { className: "flex-item" }, contact.lastName),
        React.createElement("div", { className: "flex-item" }, contact.mobile),
        React.createElement("div", { className: "flex-item" }, contact.home)))));
}
function Contact() {
    return (React.createElement("div", null,
        React.createElement(RetriveContact, null)));
}
exports.Contact = Contact;
//# sourceMappingURL=Contact.js.map