import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

type Course = {
  id: number;
  title: string;
  description: string;
  instructor: string;
};

const mockCourse: Course[] = [
  {
    id: 1,
    title: "Introduction to Web Development",
    description: "Learn the basics of HTML, CSS, and JavaScript",
    instructor: "Jonh Doe",
  },
  {
    id: 2,
    title: "React for Beginners",
    description: "Build dynamic userinterfaces with React",
    instructor: "Jane Smith",
  },
  {
    id: 3,
    title: "Advanced C# and .NET",
    description: "Deep dive into enterprise .NET development.",
    instructor: "Robert Black",
  },
];


const Courses = () => {
  const [courses, SetCourses] = useState<Course[]>([]);

  useEffect(() => {
    SetCourses(mockCourse);
  }, []);
  return (
    <div className="p-8">
      <h1 className="text-3x1 font-bold mb-6">Available Courses</h1>
      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        {courses.map((course) => (
          <Link to={`/courses/${course.id}`} key={course.id}>          
           <div className="border p-4 rounded-x1 shadow hower:shadom-md transition">
            <h2 className="text-x1 font-semibold">{course.title}</h2>
            <p className="text-gray-700 mt-2">{course.description}</p>
            <p className="text-sm text-gray-500 mt-1">Instructor: {course.instructor}</p>
          </div>
        </Link>
        ))}
    </div>
  </div>
  );
};

export default Courses;
