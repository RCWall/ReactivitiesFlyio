
import { useEffect, useState } from 'react';
import { Container } from 'semantic-ui-react';
import { Activity } from '../models/activity';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import {v4 as uuid} from 'uuid';
import agent from '../api/agent';
import LoadingComponent from './LoadingComponent';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';


function App() {
  
  const {activityStore} = useStore();

  //state variable used to store the activities that are returned from the API
  //passed to the ActivityDashboard component  as props along with the other functions and state variables
  const [activities, setActivities] = useState<Activity[]>([]);

  //this will be used to store the activity that the user clicks on
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);

  //this will be used to determine if the user is in edit mode or not
  const [editMode, setEditMode] = useState(false);


  const [submitting, setSubmitting] = useState(false);

  
  //gets the activities from the API and reformat the date
  useEffect(() => {
       activityStore.loadActivities();
  }, [activityStore])
  
  

  function handleCreateOrEditActivity(activity: Activity) {

    setSubmitting(true);
    if(activity.id){
      agent.Activities.update(activity).then(() => {
        setActivities([...activities.filter(x => x.id !== activity.id), activity])
        setSelectedActivity(activity);
        setEditMode(false);
        setSubmitting(false);
      })
    } else{
      activity.id = uuid();
      agent.Activities.create(activity).then(() => {
        setActivities([...activities, activity])
        setSelectedActivity(activity);
        setEditMode(false);
        setSubmitting(false);
      })
    }
  }

  function handleDeleteActivity(id: string) {
    setSubmitting(true);
    agent.Activities.delete(id).then(() => {
      setActivities([...activities.filter(x => x.id !== id)])
      setSubmitting(false);
    })
  }

  //renders navbar and activity dashboard components
  if (activityStore.loadingInitial) return <LoadingComponent content='Loading app' />

  return (
  <>  
   <NavBar />
   <Container style = {{ marginTop: '7em' }}>
     <ActivityDashboard
      activities={activityStore.activities} 
      createOrEdit={handleCreateOrEditActivity}
      deleteActivity={handleDeleteActivity}
      submitting={submitting}
     />
   </Container>
  </> 
  )
}

export default observer(App)
