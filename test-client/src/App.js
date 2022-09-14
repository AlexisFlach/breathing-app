import './App.css';
import axios from 'axios';
import React, { useState, useEffect } from 'react';


function App() {
  const [exerciseData, setExerciseData] = useState([]);
  const [userData, setUserData] = useState({ hits: [] });

  useEffect(() => {
    const fetchData = async () => {
      const exerciseResult = await axios(
        'http://acme.com/api/e/users/1/exercises',
      );
      setExerciseData(exerciseResult.data);
    };

    fetchData();
  }, []);

  return (
    <div className="App">
      <header className="App-header">
      <h1>Hello World</h1> 

      {exerciseData.length > 0 && exerciseData.map(item => (
        <div key={item.id}>
          <p>{item.levelId}</p>
          <p>{item.userId}</p>
          <p>{item.isFinished}</p>
          </div>
          ))} 
               
      </header>
    </div>
  );

  }
export default App;
