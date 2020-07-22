import React from 'react';


const SelectYear = (props) => { 
    const years = getYears();
  return (
    <select 
        id={props.id} 
        className="form-control" 
        onChange={e => props.onChange(e.target.value)} 
        value={props.value}
    >
        {
            years.map((y,i)=>(
                <option value={y}>{y}</option>
            ))
        }
    </select> 
  );
};
 
const getYears = function(startYear) {
    var currentYear = new Date().getFullYear(), years = [];
    startYear = startYear || 1940;  
    while ( startYear <= currentYear ) {
        years.push(startYear++);
    }   
    return years;
}

export default SelectYear;