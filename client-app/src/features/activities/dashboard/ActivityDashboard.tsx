
import { Grid } from 'semantic-ui-react';
import ActivityList from './ActivityList';
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';
import { useEffect } from 'react';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import ActivityFilters from './ActivityFilters';



// Purpose of this component is to display the ActivityList, ActivityDetails, and ActivityForm components
export default observer  (function ActivityDashboard() {

    const {activityStore} = useStore();
    const {loadActivities, activityRegistry} = activityStore;   

    //gets the activities from the API and reformat the date
    useEffect(() => {
         if (activityRegistry.size <= 1 ) loadActivities();
    }, [loadActivities, activityRegistry.size]) //dependency array, if the array is empty, the useEffect will only run once, if the array is not empty, the useEffect will run every time the dependency changes (in this case, the dependency is the loadActivities function)]])
    
  
  
    //renders navbar and activity dashboard components
    if (activityStore.loadingInitial) return <LoadingComponent content='Loading activities' />

    return (
        <Grid>
           < Grid.Column width='10'>
                <ActivityList />
           </Grid.Column>
           <Grid.Column width='6'>
            <ActivityFilters />
           </Grid.Column>
        </Grid>
    )
})