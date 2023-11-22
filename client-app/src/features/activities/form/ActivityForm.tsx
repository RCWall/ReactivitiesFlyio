
import { Segment, Form, Button } from 'semantic-ui-react';
import { useState, ChangeEvent} from 'react';
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';



//the purpose of this function is to display the form for creating and editing activities
export default observer(function ActivityForm() {
    const {activityStore} = useStore();
    const {selectedActivity, createActivity, updateActivity, loading} = activityStore;


    //if activity is null, then set the initial state to the following
    const initialState = selectedActivity ?? {
        id: '',
        title: '',
        category: '',
        description: '',
        date: '',
        city: '',
        venue: ''   
    }
    
    //this will be used to set the state of the activity
    const [activity, setActivity] = useState(initialState);

    function handleSubmit() {
        activity.id ? updateActivity(activity) : createActivity(activity);
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const {name, value} = event.target;
        setActivity({...activity, [name]: value})
    }

    return (
        <Segment clearing>
            <Form onSubmit={handleSubmit} autoComplete='off'>
                <Form.Input placeholder='Title' value={activity.title} name='title' onChange={handleInputChange}/>
                <Form.TextArea placeholder='Description' value={activity.description} name='description' onChange={handleInputChange} />
                <Form.Input placeholder='Category' value={activity.category} name='category' onChange={handleInputChange}/>
                <Form.Input type='date' placeholder='Date' value={activity.date} name='date' onChange={handleInputChange}/>
                <Form.Input placeholder='City' value={activity.city} name='city' onChange={handleInputChange}/>
                <Form.Input placeholder='Venue' value={activity.venue} name='venue' onChange={handleInputChange}/>
                <Button loading={loading} floated='right' positive type='submit' content='Submit' />
                <Button floated='right'type='button' content='Cancel' />
            </Form>
        </Segment>
    )
 })