import React from 'react';

const ButtonComponent = ({ onClick, text }) => { 
    return ( <button onClick={onClick} className="buttons"> 
            {text} 
        </button> 
    );
};

export default ButtonComponent;