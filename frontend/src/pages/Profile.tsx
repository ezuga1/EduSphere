const Profile = () => {
  const user = JSON.parse(localStorage.getItem("user") || "{}");

  return (
    <div className="max-w-2x1 mx-auto p-8">
      <h1 className="text-3x1 font-bold mb-4">Profile</h1>
      <p className="mb-4">Welcome, <strong>{user?.email || "Guest"}</strong></p>

      {/* Dummy user data */}
      <div className="mt-6">
        <h2 className="text-xl font-semibold mb-2">My Courses</h2>
        <ul className="list-disc ml-6 text-gray-700">
          <li>React Fundamentals</li>
          <li>Intro to .NET</li>
        </ul>

        <h2 className="text-xl font-semibold mt-6 mb-2">My Events</h2>
        <ul className="list-disc ml-6 text-gray-700">
          <li>React Bootcamp</li>
        </ul>
      </div>
    </div>
  );
};

export default Profile;