import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

type Event = {
  id: number;
  name:string;
  date: string;
  location: string;
  description: string;
  details?: string;
};

const mockEvents : Event[] = [
  {
    id: 1,
    name: "JavaScript Conference 2025",
    date: "2025-09-15",
    location: "Online",
    description: "Virtual conference about modern JavaScript.",
    details: "Join industry leaders and engineers in discussions and workshops around JavaScript, including React, Vue, and Svelte.",
  },
  {
    id: 2,
    name: "AI in Education",
    date: "2025-10-03",
    location: "Berlin, Germany",
    description: "AI in modern learning environments.",
    details: "Speakers from top EdTech companies will explore the role of machine learning and large language models in shaping the future of education.",
  },
  {
    id: 3,
    name: "React Bootcamp",
    date: "2025-08-20",
    location: "New York, USA",
    description: "Hands-on bootcamp to master React.",
    details: "This bootcamp is ideal for intermediate developers aiming to build production-grade applications with React, Tailwind, and advanced tooling.",
  },
];


const EventDetails = () => {
  const {id} = useParams();
  const [event, setEvent] = useState<Event | null>(null);

  useEffect(() => {
    const foundEvent = mockEvents.find(e => e.id === Number(id));
    setEvent(foundEvent || null);

  }, [id]);

  if(!event) return <div className="p-8 text-red-500">Event not found.</div>;
  
  return(
    <div className="p-8">
      <h1 className="text-3x1 font-bold mb-4">{event.name}</h1>
      <p className="text-gray-600 mb-2">{event.date} | {event.location}</p>
      <p className="text-gray-700 mb-4">{event.description}</p>
      <p className="text-white-800">{event.details}</p>
    </div>
  );
};

export default EventDetails;