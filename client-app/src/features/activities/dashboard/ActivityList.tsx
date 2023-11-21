
import { SyntheticEvent, useState } from 'react';
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';
import { Button, Item, Label, Segment } from 'semantic-ui-react';



// 3. Create the ActivityList component
export default observer (function ActivityList() {
    const {activityStore} = useStore();
    const {deleteActivity, activitiesByDate, loading} = activityStore; // 2. Destructure the deleteActivity function from the activityStore
    
    const [target, setTarget] = useState(''); // 4. Create a state for the target button

    function handleActivityDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        setTarget(e.currentTarget.name); // 5. Set the target button
        deleteActivity(id);
    }

    return (
        <Segment>
            <Item.Group divided>
                {/*map each activity to an item*/}
                {activitiesByDate.map(activity => (
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
                                    loading={loading && target === activity.id} 
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
    )})

