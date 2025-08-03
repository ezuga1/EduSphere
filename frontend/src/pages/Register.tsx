import { useState } from "react";
import { useNavigate } from "react-router-dom";

const Register = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault(); 

    if(email && password){
       localStorage.setItem("user", JSON.stringify({email}));
       navigate("/profile");
    }
  };

  return (
    <div className="max-w-md mx-auto p-8">
      <h2 className="text-2x1 font-bold mb-6">Register</h2>
      <form onSubmit={handleSubmit} className="space-y-4">
        <input 
        type="email"
        placeholder="Email"
        className="w-full p-2 border rounded"
        value={email}
        onChange = {(e) => setEmail(e.target.value)}
        required
        />
        <input 
        type="password"
        placeholder="Password"
        className="w-full p-2 border rounded"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        required
        />
        <button type="submit" className="bg-green-600 text-white py-2 px-4 rounded hover:bg-green-700">
          Register
        </button> 
      </form>

    </div>
  )
};

export default Register;