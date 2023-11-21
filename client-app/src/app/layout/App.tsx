
import { useEffect } from 'react';
import { Container } from 'semantic-ui-react';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import LoadingComponent from './LoadingComponent';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';


function App() {
  
  const {activityStore} = useStore();


  
  //gets the activities from the API and reformat the date
  useEffect(() => {
       activityStore.loadActivities();
  }, [activityStore])
  


  //renders navbar and activity dashboard components
  if (activityStore.loadingInitial) return <LoadingComponent content='Loading app' />

  return (
  <>  
   <NavBar />
   <Container style = {{ marginTop: '7em' }}>
     <ActivityDashboard/>
   </Container>
  </> 
  )
}

export default observer(App)
