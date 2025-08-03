import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

type Event = {
  id: number;
  name: string;
  date: string;
  location: string;
  description: string;
};

const mockEvents : Event [] = [
  {
    id: 1,
    name: "JavaScript Conference 2025",
    date: "2025-09-15",
    location: "Online",
    description: "A virtual conference covering modern JavaScript frameworks and best practices.",
  },
  {
    id: 2,
    name: "AI in Education",
    date: "2025-10-03",
    location: "Berlin, Germany",
    description: "Exploring the impact of artificial intelligence in modern learning environments.",
  },
  {
    id: 3,
    name: "React Bootcamp",
    date: "2025-08-20",
    location: "New York, USA",
    description: "An intensive bootcamp focused on building production-ready React applications.",
  },
];



const Events = () => {
 const [events, setEvents] = useState<Event[]>([]);

 useEffect(() => {
  setEvents(mockEvents);
 }, []);

 return (
  <div className="p-8">
    <h1 className="text-3x1 font-bold mb-6">Ecudational Events</h1>
    <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
      {events.map(event => (
        <Link to={`/events/${event.id}`} key={event.id} className="border rounded-x1 p-6 shadow hower:shadow-md transition">        
         <div >
          <h2 className="text-x1 font-semibold">{event.name}</h2>
          <p className="text-gray-600 mt-1">{event.location}</p>
          <p className="text-gray-700 mt-2">{event.description}</p>
        </div>
      </Link>
      ))}
    </div>
  </div>
 )
 };

export default Events;