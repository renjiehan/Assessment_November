// import logo from './logo.svg';
import React, { useState, useEffect } from 'react';
import axios from 'axios';

import './App.css';
import ButtonComponent from './ButtonComponent';

function App() {
  const [xVal, setXVal] = useState('');
  const onXValChange = (event) => { setXVal(event.target.value); };

  const [yVal, setYVal] = useState('');
  const onYValChange = (event) => { setYVal(event.target.value); };

  const [jsonData, setJsonData] = useState('');
  
  const handleButtonClick = async (apiUrl, params) => {
    try {
      const url = new URL(apiUrl);
      Object.keys(params).forEach(key => 
          url.searchParams.append(key, params[key])
      ); 

      const response = await axios.get(url);

      const data = response.data;
      const formattedData = JSON.stringify(data, null, 1)
        .replace(/\[/g, '')
        .replace(/\]/g, '')
        .replace(/"/g, '');

      setJsonData(formattedData);
      if(formattedData === "")  setJsonData("Please make sure X and Y are both greater than zero.");

      console.log(`Success from ${url}, data is:`, data);
      console.log(`Success from ${url}:`, formattedData);
    } 
    catch (error) {
      console.error(`Error from ${apiUrl}:`, error); 
    }
  };

  return (
    <div className="App">
      <header className='App-header'>
        Functions Playground
      </header>

      <div>
        <h3>
          Please give X and Y values
        </h3>

        <h5>
          X is the amount of numbers returned. 
        </h5>

        <h5>
          Y is lower threshold number for "Get Prime Numbers" and "Get Fibonacci Numbers", <br></br>
          for "Get Random Characters, it is a seed for randomness"
        </h5>

        <p>
          For example, given X = 10, Y = 3498, and <b>press</b> Get Prime Numbers. <br></br>
          You will get 10 prime numbers above 3498, not including 3498.
        </p>
        <p>
          For function "Get Random Characters", you will get characters from A - Z, or a - z or 0 - 9.
        </p>
      </div>

      <div id="text-inputs" className="card-body">
        <div id="input_box" className="textbox-align">
          <div id="textbox_x" className="textbox-elem-align input-box">
            <label className="labels">X</label> 
            <input type="number" id="textbox_x" className="" value={xVal} onChange={onXValChange}></input>
          </div>

          <div id="textbox_y" className="textbox-elem-align input-box">
            <label className="labels">Y</label>
            <input type="number" id="textbox_y" className="" value={yVal} onChange={onYValChange}></input>
          </div>
        </div>
      </div>

      <div id="box_row" className="card-body"> 
        <ButtonComponent
          onClick={() => 
            handleButtonClick('https://localhost:7193/Endpoints/GetPrimes', { retSize: xVal, startFrom: yVal })
          }
          text="Get Prime Numbers" />
        <ButtonComponent
          onClick={() => 
            handleButtonClick('https://localhost:7193/Endpoints/GetFibonacci', { retSize: xVal, startFrom: yVal })
          }
          text="Get Fibonacci Numbers" />
        <ButtonComponent
          onClick={() => 
            handleButtonClick('https://localhost:7193/Endpoints/GetRandChars', { retSize: xVal, seed: yVal })
          }
          text="Get Random Characters" />        
      </div>

      <h5>Result</h5>
      <div className="textbox-align" readOnly> 
        <div className="border-margin">
            {jsonData}
        </div>
      </div>

      
    </div>
  );
}

export default App;
