import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <nav className="bg-gray-800 text-white p-4">
      <div className="container mx-auto flex justify-between items-center">
        <h1 className="text-x1 font-bold">
          <Link to="/">EduSphere</Link>
        </h1>
        <div className="space-x-4">
          <Link to="/" className="hover:underline">Home</Link>
          <Link to="/courses" className="hover:underline">Courses</Link>
          <Link to="/events" className="hover:underline">Events</Link>
          <Link to="/login" className="hover:underline">Login</Link>
          <Link to="/register" className="hover:underline">Register</Link>
          <Link to="/profile" className="hover:underline">Profile</Link>
          <Link to="/login" className="hover:underline">Logout</Link>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;