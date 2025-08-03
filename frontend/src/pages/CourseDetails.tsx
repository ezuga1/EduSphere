import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

type Course = {
  id: number;
  title: string;
  description: string; 
  instructor: string;
  content: string;
};

const mockCourses: Course[] = [
  {
    id: 1,
    title: "Introduction to Web Development",
    description: "Learn the basics of HTML, CSS, and JavaScript.",
    instructor: "John Doe",
    content: "This course covers HTML structure, CSS styling, and JavaScript fundamentals...",
  },
  {
    id: 2,
    title: "React for Beginners",
    description: "Build dynamic user interfaces with React.",
    instructor: "Jane Smith",
    content: "You'll learn about components, hooks, props, state, and more.",
  },
  {
    id: 3,
    title: "Advanced C# and .NET",
    description: "Deep dive into enterprise .NET development.",
    instructor: "Robert Black",
    content: "Explore advanced .NET topics like dependency injection, Entity Framework, etc.",
  },
];

const CourseDetails = () => {
  const {id} = useParams();
  
  const [course, setCourse] = useState<Course | null>(null);

  useEffect(() => {
    const found = mockCourses.find(c => c.id === Number(id));
    setCourse(found || null);
  }, [id]);

  if(!course) return <div className="p-8 text-red-500">Course not found.</div>
  return (
    <div className="p-8">
      <h1 className="text-3x1 font-bold mb-4">{course.title}</h1>
      <p className="text-gray-700 mb-2">{course.description}</p>
      <p className="text-sm text-gray-500 mb-6">Instructor: {course.instructor}</p>
      <h2 className="text-x1 font-semibold mb-2">Course Content</h2>
      <p className="text-black-800">{course.content}</p>
    </div>
  );
};

export default CourseDetails;