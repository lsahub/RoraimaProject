import React, { useEffect, useState, useRef, createRef } from 'react';
import ResumeVisiibility from 'containers/resumeVisibility';
import { connect } from 'react-redux';
import { saveResume } from 'actions/resume';
import ResumeExperience from 'containers/resumeExperience';
import {smoothScroll} from 'selectors'
import Advertising from 'containers/advertising';
import { withRouter } from 'react-router-dom';
const Fragment = React.Fragment;
 
const Resume = (props) => {
  const [isSaveResume, setIsSaveResume] = useState(false);
  const [resumeTitle, setResumeTitle] = useState("");

  const [lastName, setLastName] = useState("");
  const [firstName, setFirstName] = useState("");
  const [middleName, setMiddleName] = useState("");
  const [resumeVisibilityId, setResumeVisibility] = useState(1);
  //#region ResumeExperience
  const [maxIndexResumeExperience, setMaxIndexResumeExperience] = useState(1);
  const [dateStartMonthList, setDateStartMonth] = useState([1]);
  const [dateStartYearList, setDateStartYear] = useState([2020]);

  const [dateEndMonthList, setDateEndMonth] = useState([1]);
  const [dateEndYearList, setDateEndYear] = useState([2020]);

  const [isUntilTimeList, setIsUntilTimeList] = useState([0, false]);
  const [positionList, setPositionList] = useState([,]);
  const [placeOfWorkList, setPlaceOfWorkList] = useState([,]);
  const [descriptionList, setDescriptionList] = useState([,]);
  //#endregion  

  //#region useRef
  const resumeTitleRef = useRef(null);
  const lastNameRef = useRef(null);
  const firstNameRef = useRef(null);
  const resumeExperienceRefs = [];
  //#endregion

  //#region validate
  const [isValidateResumeTitle, setIsValidateResumeTitle] = useState(true);
  const [isValidateLastName, setIsValidateLastName] = useState(true);
  const [isValidateFirstName, setIsValidateFirstName] = useState(true);
  //#endregion

  //#region resetValidate
  let resetValidate = () =>
  {
    setIsValidateResumeTitle(true);
    setIsValidateLastName(true);
    setIsValidateFirstName(true);
  }
  //#endregion

  //#region validate
  let validate = () =>
  {
    resetValidate();
    let isValid = true;
    let smoothRef = null;
    if(!resumeTitle)
    {
      setIsValidateResumeTitle(false);
      if(smoothRef == null)
        smoothRef = resumeTitleRef;
      isValid = false;
    }
    if(!lastName)
    {      
      setIsValidateLastName(false);
      if(smoothRef == null)
        smoothRef = lastNameRef;
      isValid = false;
    }

    if(!firstName)
    {      
      setIsValidateFirstName(false);
      if(smoothRef == null)
        smoothRef = firstNameRef;
      isValid = false;
    }
    
    if(smoothRef != null)
      smoothScroll(smoothRef);

    return isValid;
  }
  const lastDayOfMonth = (y,m) => {
    return  new Date(y, m +1, 0).getDate();
  }    
  //#endregion

  //#region validateExperience
  const validateExperience = (isValid)=> 
  {
    resumeExperienceRefs.forEach(ref => {
      if(!ref.current.validateExperience(isValid))
      isValid = false;
    });
    return isValid;
  }
  //#endregion

  //#region save
  useEffect(() => {   
    let isValid = false; 
    if(isSaveResume)
    {
      isValid = validate();
      isValid = validateExperience(isValid);
    }

    if(isSaveResume && isValid)
    {      
      let resumeExperienceList = [];
      for (let index = 0; index < maxIndexResumeExperience; index++) {
        let dateStartMonth = ('0' + (dateStartMonthList[index]).toString()).slice(-2);
        let dateStartYear = dateStartYearList[index];
        let dateStart =  new Date(`${dateStartYear}-${dateStartMonth}-01T00:00:00.000Z`);

        let isUntilTime = isUntilTimeList[index];
        let dateEndMonth = null;
        let dateEndYear = null;
        let dateEnd = null;

        if(!isUntilTime)
        {
          dateEndMonth = ('0' + (dateEndMonthList[index]).toString()).slice(-2);
          dateEndYear = dateEndYearList[index];
          dateEnd =  new Date(`${dateEndYear}-${dateEndMonth}-${lastDayOfMonth(dateEndYear, dateEndMonth)}T00:00:00.000Z`)
        }
        let position = positionList[index];
        let placeOfWork = placeOfWorkList[index];
        let description = descriptionList[index];
        let resumeExperience =  { dateStart,dateEnd,isUntilTime,position,placeOfWork,description };
        resumeExperienceList.push(resumeExperience);
      }

      props.saveResume({
        resumeTitle,
        lastName,
        firstName,
        middleName,
        resumeVisibilityId,
        resumeExperienceList
      }).then(()=>{
        props.history.push(`/resumeSent`);
      });
    }

    setIsSaveResume(false);

  }, [isSaveResume]);
  //#endregion 

  return (
    <Fragment>
      <div className="page-resume">
          <div className="card">
            <div className="card-body">
              <div className='form-group row'>
                <div className="col-sm-8 media-order-2">
                  <h1 className="card-title pricing-card-title">Ваше резюме</h1>
                    <div className="form-group row">
                      <label htmlFor="inputTitle" className="col-sm-3 col-form-label">Желаемая должность</label>
                      <div className="col-sm-9">
                        <input 
                          value={resumeTitle} 
                          onChange={e => setResumeTitle(e.target.value)} 
                          className="form-control" 
                          id="inputTitle" 
                          placeholder="Желаемая должность" 
                          maxLength="500" 
                          ref={resumeTitleRef}
                        />
                        {
                          !isValidateResumeTitle &&
                          <small className="text-danger">Обязательное поле</small> 
                        }  
                      </div>
                    </div>

                    <div className="form-group row">
                      <label htmlFor="inputLastName" className="col-sm-3 col-form-label">Фамилия</label>
                      <div className="col-sm-9">
                        <input 
                          value={lastName} 
                          onChange={e => setLastName(e.target.value)}  
                          className="form-control" 
                          id="inputLastName" 
                          placeholder="Фамилия" 
                          maxLength="100" 
                          ref={lastNameRef}
                        />
                        {
                          !isValidateLastName &&
                          <small className="text-danger">Обязательное поле</small> 
                        }                      
                      </div>                      
                    </div>
                    <div className="form-group row">
                      <label htmlFor="inputFirstName" className="col-sm-3 col-form-label">Имя</label>
                      <div className="col-sm-9">
                        <input 
                          value={firstName} 
                          onChange={e => setFirstName(e.target.value)} 
                          className="form-control" 
                          id="inputFirstName" 
                          placeholder="Имя" 
                          maxLength="100" 
                          ref={firstNameRef}
                        />
                        {
                          !isValidateFirstName &&
                          <small className="text-danger">Обязательное поле</small> 
                        }  
                      </div>
                    </div>
                    <div className="form-group row">
                      <label htmlFor="inputMiddleName" className="col-sm-3 col-form-label">Отчество</label>
                      <div className="col-sm-9">
                        <input value={middleName} onChange={e => setMiddleName(e.target.value)} className="form-control" id="inputMiddleName" placeholder="Отчество" maxLength="100" />
                      </div>
                    </div>
                    <div>
                        <ResumeVisiibility value={resumeVisibilityId} onChange={setResumeVisibility} />
                    </div>
                    {
                      [...Array(maxIndexResumeExperience)].map((x, index) => {
                        //#region  при добавлении новых элементов инициализируем их дефолтными значениями
                        resumeExperienceRefs[index] = createRef();
                        if(!dateStartYearList[index])
                          dateStartYearList[index] = 2020;
                        if(!dateEndYearList[index])
                          dateEndYearList[index] = 2020;
                        //#endregion 
                        return (
                          <div key={`DivResumeExperience${index}`}>
                            <ResumeExperience                            
                              key={`ResumeExperience${index}`}
                              index={index}                            
                              ref={resumeExperienceRefs[index]}
                              setDateStartMonth={setDateStartMonth} 
                              setDateEndMonth={setDateEndMonth} 
                              setDateStartYear={setDateStartYear} 
                              setDateEndYear={setDateEndYear} 

                              setIsUntilTimeList={setIsUntilTimeList}
                              setPositionList={setPositionList}
                              setPlaceOfWorkList={setPlaceOfWorkList}
                              setDescriptionList={setDescriptionList}
                              
                              dateStartMonthList={dateStartMonthList}
                              dateStartYearList={dateStartYearList}

                              dateEndMonthList={dateEndMonthList} 
                              dateEndYearList={dateEndYearList} 

                              isUntilTimeList={isUntilTimeList} 
                              positionList={positionList}
                              placeOfWorkList={placeOfWorkList}
                              descriptionList={descriptionList}
                              deleteResumeExperience={(i=>{
                                alert('функция удаления не реализована')
                              })}
                            />
                          </div>
                      )})
                    }
                    <div className="resume-experience-add">
                      <button 
                        type="button" 
                        className="btn btn-link" 
                        onClick={()=>{
                          setMaxIndexResumeExperience(maxIndexResumeExperience + 1)
                        }}
                      >Добавить место работы</button>
                    </div>
                  <button onClick={(event)=>{setIsSaveResume(true)}} type="button" className="btn btn-lg btn-outline-primary">Сохранить</button>
              
                </div>
                <Advertising />
              </div>
            </div>
          </div> 
 
      </div>
    </Fragment>


  );
};

const mapDispatch = {
  saveResume
};

export default connect(null, mapDispatch)(withRouter(Resume));