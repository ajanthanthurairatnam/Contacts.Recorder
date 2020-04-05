import * as React from "react";
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import { useEffect } from "react";
import { FormControlLabel } from "@material-ui/core";

interface IContactDialog{
    save(props:IContact):void,
    contactDetail:IContact
}

export interface IContact
{
    id?:string,
    firstName:string,
    lastName:string,
    mobile:string,
    home:string
}

export  function ContactDialog(props:IContactDialog) {

  const {save,contactDetail} ={...props}
  const [open, setOpen] = React.useState<boolean>(false);
  const [contact, setContact] = React.useState<IContact>({firstName:"",home:"",lastName:"",mobile:""});


  useEffect(() => {
    // Update the document title using the browser API
    setContact({...contactDetail});
 
  },[contactDetail.id]);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const saveAndClose = () => {
    setContact({id:null, firstName:"",home:"",lastName:"",mobile:""});
    save({...contact});
    handleClose();
  };

  const getContact=(id:string)=>{
    $.getJSON(`Home/GetById?id=${id}`, function(contact:IContact) {
       setContact(contact)
      });
    }

  return (
    <div>
            <Button variant="outlined" color="primary" onClick={handleClickOpen}>
              {(contactDetail.id==null || contactDetail.id=="") ? "Add" : contactDetail.id}
            </Button>
      <Dialog open={open} onClose={handleClose} aria-labelledby="form-dialog-title">
        <DialogTitle id="form-dialog-title">Subscribe</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Please enter contact details.
          </DialogContentText>
          {
            ( contact.id!=null || contact.id!="")?
            contact.id:""
          }
          <TextField
            autoFocus
            margin="dense"
            id="firstName"
            label="First Name"
            type="text"
            defaultValue={contact.firstName}
            onBlur={
                (e)=>
                    {
                        const con={...contact};
                        con.firstName=e.target.value;
                        setContact(con);
                    }
                }
            fullWidth
          />
        <TextField
            margin="dense"
            id="lastName"
            label="Last Address"
            defaultValue={contact.lastName}
            type="text"
            onBlur={
                (e)=>
                    {
                        const con={...contact};
                        con.lastName=e.target.value;
                        setContact(con);
                    }
                }
            fullWidth
          />
        <TextField
            margin="dense"
            id="mobile"
            label="Mobile"
            defaultValue={contact.mobile}
            type="text"
            onBlur={
                (e)=>
                    {
                        const con={...contact};
                        con.mobile=e.target.value;
                        setContact(con);
                    }
                }
            fullWidth
          />
          <TextField
            margin="dense"
            id="home"
            label="Home"
            defaultValue={contact.home}
            type="text"
            onBlur={
                (e)=>
                    {
                        const con={...contact};
                        con.home=e.target.value;
                        setContact(con);
                    }
                }
            fullWidth
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} color="primary">
            Cancel
          </Button>
          <Button onClick={saveAndClose} color="primary">
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}
