
import { Grid } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';
import ActivityList from './ActivityList';
import ActivityDetails from '../details/ActivityDetails';
import ActivityForm from '../form/ActivityForm';

// Define the Props interface for the ActivityDashboard component
interface Props {
    activities: Activity[];                     // Array of Activity objects
    selectedActivity: Activity | undefined;     // Currently selected Activity object
    selectActivity: (id: string) => void;       // Function to select an Activity
    cancelSelectActivity: () => void;           // Function to cancel the selection of an Activity
    editMode: boolean;                          // Boolean to determine if the user is in edit mode
    openForm: (id: string) => void;             // Function to open the form
    closeForm: () => void;
    createOrEdit: (activity: Activity) => void; 
    deleteActivity: (id: string) => void;                    
}

// Purpose of this component is to display the ActivityList, ActivityDetails, and ActivityForm components
export default function ActivityDashboard({activities, selectedActivity, 
    selectActivity, cancelSelectActivity, editMode, openForm, closeForm, createOrEdit, deleteActivity}: Props) {
    return (
        <Grid>
           < Grid.Column width='10'>
                {/*ActivityList component, passing activities and selectActivity as props*/}
                <ActivityList activities={activities} 
                    selectActivity={selectActivity} 
                    deleteActivity={deleteActivity} />
           </Grid.Column>
           <Grid.Column width='6'>
            {/*only loads ActivityDetails component if there is an activity and not in edit mode*/}
            {selectedActivity && !editMode &&
             <ActivityDetails activity={selectedActivity} 
                cancelSelectActivity={cancelSelectActivity} 
                openForm={openForm}
             />}
             {/*ActivityForm component only renders if editmode set to true*/}
             {editMode &&
             <ActivityForm closeForm={closeForm} activity={selectedActivity} createOrEdit={createOrEdit}/>}
           </Grid.Column>
        </Grid>
    )
}