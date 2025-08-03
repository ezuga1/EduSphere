import './App.css'
import { Route, Routes } from 'react-router-dom'
import Home from './pages/Home'
import Courses from './pages/Courses'
import CourseDetails from './pages/CourseDetails'
import Events from './pages/Events'
import EventDetails from './pages/EventDetail'
import Login from './pages/Login'
import Register from './pages/Register'
import Profile from './pages/Profile'
import Navbar from './components/Navbar'
const App = () => {
  return (
  <>
    <Navbar />
    <Routes>
      <Route path = "/" element = {<Home />} />
      <Route path='/courses' element={<Courses />} />
      <Route path='/courses/:id' element={<CourseDetails />} />
      <Route path='/events' element={<Events />} />
      <Route path='/events/:id' element = {<EventDetails />} />
      <Route path='/login' element = {<Login />} />
      <Route path='register' element = {<Register />} />
      <Route path='/profile' element = {<Profile />} />
    </Routes>
  </>
  );
;}

export default App;