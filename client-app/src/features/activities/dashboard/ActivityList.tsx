import React from 'react' ;
import { Activity } from '../../../app/models/activity';    // 1. Import the Activity interface
import { Segment, Item, Button, Label } from 'semantic-ui-react';

// 2. Create the Props interface
interface Props {
    activities: Activity[];
    selectActivity: (id: string) => void;
}

// 3. Create the ActivityList component
export default function ActivityList({activities, selectActivity}: Props) {
    return (
        <Segment>
            <Item.Group divided>
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
                                <Button onClick={() => selectActivity(activity.id)} floated='right' content='View' color='blue' />
                                <Label basic content={activity.category} />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>       
        </Segment>
    )} 

