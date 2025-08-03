const Home = () => {
  return (
    <div className="p-8 text-center">
      <h1 className="text-4x1 font-bold mb-4">Welcome to EduSphere</h1>
      <p className="text-lg mb-6">
        Discover a world of knowledge through our curated online courses and educational events.
      </p>
      <div className="flex justify-center gap-4">
        <a 
          href="/courses"
          className="px-6 py-2 bg-blue-600 text-white rounded-xl hover:bg-blue-700 transition"
          >
            Browse Courses
          </a>
          <a 
          href="/events"
          className="px-6 py-2 bg-gray-200 text-black rounded-xl hover:bg-gray-300 transition"
          >
            Upcoming Events
          </a>
      </div>
    </div>
  );
};  

export default Home;