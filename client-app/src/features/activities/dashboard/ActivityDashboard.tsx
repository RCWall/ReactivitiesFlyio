
import { Grid } from 'semantic-ui-react';
import ActivityList from './ActivityList';
import ActivityDetails from '../details/ActivityDetails';
import ActivityForm from '../form/ActivityForm';
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';



// Purpose of this component is to display the ActivityList, ActivityDetails, and ActivityForm components
export default observer  (function ActivityDashboard() {

    const {activityStore} = useStore();
    const {selectedActivity, editMode} = activityStore;

    return (
        <Grid>
           < Grid.Column width='10'>
                {/*ActivityList component, passing activities and selectActivity as props*/}
                <ActivityList />
           </Grid.Column>
           <Grid.Column width='6'>
            {/*only loads ActivityDetails component if there is an activity and not in edit mode*/}
            {selectedActivity && !editMode &&
             <ActivityDetails/>}
             {/*ActivityForm component only renders if editmode set to true*/}
             {editMode &&
             <ActivityForm />}
           </Grid.Column>
        </Grid>
    )
})