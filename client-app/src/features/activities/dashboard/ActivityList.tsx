
import { SyntheticEvent, useState } from 'react';
import { Activity } from '../../../app/models/activity';    // 1. Import the Activity interface
import { Segment, Item, Button, Label } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';

// 2. Create the Props interface
interface Props {
    activities: Activity[];
    deleteActivity: (id: string) => void;
    submitting: boolean;
}

// 3. Create the ActivityList component
export default function ActivityList({activities, deleteActivity, submitting}: Props) {
    
    const [target, setTarget] = useState(''); // 4. Create a state for the target button

    function handleActivityDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        setTarget(e.currentTarget.name); // 5. Set the target button
        deleteActivity(id);
    }

    const {activityStore} = useStore();

    return (
        <Segment>
            <Item.Group divided>
                {/*map each activity to an item*/}
                {activities.map(activity => (
                    <Item  key={activity.id}>
                        <Item.Content>
                           <Item.Header as='a'>{activity.title}</Item.Header>
                           <Item.Meta>{activity.date}</Item.Meta>
                           <Item.Description>
                               <div>{activity.description}</div>
                               <div>{activity.city}, {activity.venue}</div>
                           </Item.Description>
                            <Item.Extra>
                                <Button onClick={() => activityStore.selectActivity(activity.id)} floated='right' content='View' color='blue' />
                                <Button
                                    name={activity.id}
                                    loading={submitting && target === activity.id} 
                                    onClick={(e) => handleActivityDelete(e, activity.id)} 
                                    floated='right' 
                                    content='Delete' 
                                    color='red' />
                                <Label basic content={activity.category} />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>       
        </Segment>
    )} 

