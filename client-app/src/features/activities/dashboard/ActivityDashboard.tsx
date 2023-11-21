
import { Grid } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';
import ActivityList from './ActivityList';
import ActivityDetails from '../details/ActivityDetails';
import ActivityForm from '../form/ActivityForm';
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';

// Define the Props interface for the ActivityDashboard component
interface Props {
    activities: Activity[];                     // Array of Activity objects
    createOrEdit: (activity: Activity) => void; 
    deleteActivity: (id: string) => void;
    submitting: boolean;                    
}

// Purpose of this component is to display the ActivityList, ActivityDetails, and ActivityForm components
export default observer  (function ActivityDashboard({activities, 
    createOrEdit, 
    deleteActivity, submitting}: Props) {

    const {activityStore} = useStore();
    const {selectedActivity, editMode} = activityStore;

    return (
        <Grid>
           < Grid.Column width='10'>
                {/*ActivityList component, passing activities and selectActivity as props*/}
                <ActivityList activities={activities}           
                    deleteActivity={deleteActivity}
                    submitting={submitting} />
           </Grid.Column>
           <Grid.Column width='6'>
            {/*only loads ActivityDetails component if there is an activity and not in edit mode*/}
            {selectedActivity && !editMode &&
             <ActivityDetails/>}
             {/*ActivityForm component only renders if editmode set to true*/}
             {editMode &&
             <ActivityForm       
                createOrEdit={createOrEdit} 
                submitting={submitting}/>}
           </Grid.Column>
        </Grid>
    )
})