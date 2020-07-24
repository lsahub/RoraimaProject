import React, {useState, forwardRef, useRef, useImperativeHandle} from 'react';
import SelectMonth from 'components/month';
import SelectYear from 'components/year';
import { smoothScroll } from 'selectors'
const Fragment = React.Fragment;

const ResumeExperience = forwardRef((props, ref) => {
    const [isPlaceOfWorkValidate, setIsPlaceOfWorkValidate] = useState(true);
    const [isPositionValidate, setIsPositionValidate] = useState(true);
    const [isDescriptionValidate, setIsDescriptionValidate] = useState(true);
    //#region useRef
    const placeOfWorkRef = useRef(null);
    const positionRef = useRef(null);
    const descriptionRef = useRef(null);
    //#endregion

    useImperativeHandle(ref, () => ({
        validateExperience(initIsValidate) {
            setIsPlaceOfWorkValidate(true);
            setIsPositionValidate(true);
            setIsDescriptionValidate(true);

            if(!props.placeOfWorkList[props.index])
            {
                setIsPlaceOfWorkValidate(false);
                if(initIsValidate)
                    smoothScroll(placeOfWorkRef);
                initIsValidate = false;
            }

            if(!props.positionList[props.index])
            {
                setIsPositionValidate(false);
                if(initIsValidate)
                    smoothScroll(positionRef);
                initIsValidate = false;
            }

            if(!props.descriptionList[props.index])
            {
                setIsDescriptionValidate(false);
                if(initIsValidate)
                    smoothScroll(descriptionRef);
                initIsValidate = false;
            }

            return initIsValidate;
        }
    }));

    const [showEndDate, setShowEndDate] = useState(true);
    return (
    <Fragment>
        <div className="resume-experience">
        
            <div className="form-group row">
                <label htmlFor={`placeOfWork${props.index}`} className="col-sm-3 col-form-label">Место работы</label>
                <div className="col-sm-9">
                    <input 
                        value={props.placeOfWorkList[props.index]}
                        onChange={e=>{
                            let newPlaceOfWorkList = Object.assign([,],props.placeOfWorkList);
                            newPlaceOfWorkList[props.index] = e.target.value;
                            props.setPlaceOfWorkList(newPlaceOfWorkList)
                        }}
                        className="form-control" 
                        id={`placeOfWork${props.index}`}
                        placeholder="Место работы" 
                        maxLength="200" 
                        ref={placeOfWorkRef}
                    />
                        {
                          !isPlaceOfWorkValidate &&
                          <small className="text-danger">Обязательное поле</small> 
                        }  
                </div>
            </div>

            <div className="form-group row">
                <label htmlFor={`position${props.index}`} className="col-sm-3 col-form-label">Должность</label>
                <div className="col-sm-9">
                    <input 
                        value={props.positionList[props.index]}
                        onChange={e=>{ 
                            let newPositionList = Object.assign([,],props.positionList);
                            newPositionList[props.index] = e.target.value;
                            props.setPositionList(newPositionList)
                        }}
                        className="form-control" 
                        id={`position${props.index}`}
                        placeholder="Должность" 
                        maxLength="200" 
                        ref={positionRef}
                    />
                        {
                          !isPositionValidate &&
                          <small className="text-danger">Обязательное поле</small> 
                        }  
                </div>
            </div>

            <div className="form-group row">
                <label htmlFor="dateStartMonth" className="col-sm-3 col-form-label">Начало работы</label>
                <div className="col-sm-9">
                    <div className="resume-experience-date">
                        <div className="resume-experience-date-month">
                            <SelectMonth 
                                id="dateStartMonth" 
                                value={props.dateStartMonthList[props.index]} 
                                onChange={value=>{
                                    let newDateStartMonthList = Object.assign([,],props.dateStartMonthList);
                                    newDateStartMonthList[props.index] = value;
                                    props.setDateStartMonth(newDateStartMonthList)
                            }}  />
                        </div>
                        <div className="resume-experience-date-year">
                                <SelectYear 
                                    value={props.dateStartYearList[props.index]} 
                                    onChange={value => {
                                        let newDateStartYearList = Object.assign([,],props.dateStartYearList);
                                        newDateStartYearList[props.index] = value;
                                        props.setDateStartYear(newDateStartYearList)
                                    }}  
                                />
                        </div>                        
                    </div>
                </div>
            </div>
            <div className="form-group row">
                <label htmlFor="dateEndMonth" className="col-sm-3 col-form-label">Окончание</label>
                <div className="col-sm-9">
                    <div className="form-check">
                    <input 
                        value={props.isUntilTimeList[props.index]}
                        className="form-check-input" 
                        type="checkbox" 
                        id={`chbIsUntilTime${props.index}`} 
                        onChange={e=>{
                            let newIsUntilTimeList = Object.assign([,],props.isUntilTimeList);
                            newIsUntilTimeList[props.index] = e.target.value == true;
                            props.setIsUntilTimeList(newIsUntilTimeList)
                            setShowEndDate(!showEndDate);
                        }}
                    />
                    <label className="form-check-label" htmlFor={`chbIsUntilTime${props.index}`} >
                        По настоящее время
                    </label>
                    </div>
                    <div className="resume-experience-date">
                        <div className="resume-experience-date-month">
                            {
                                showEndDate == true && 
                                <SelectMonth id="dateEndMonth" 
                                    value={props.dateEndMonthList[props.index]} 
                                    onChange={value => {
                                        let newDateEndMonthList = Object.assign([,],props.dateEndMonthList);
                                        newDateEndMonthList[props.index] = value;
                                        props.setDateEndMonth(newDateEndMonthList)
                                    }}  
                                />
                            }
                        </div>
                        <div className="resume-experience-date-year">
                            {
                                showEndDate == true && 
                                <SelectYear 
                                    value={props.dateEndYearList[props.index]} 
                                    onChange={value => {
                                        let newDateEndYearList = Object.assign([,],props.dateEndYearList);
                                        newDateEndYearList[props.index] = value;
                                        props.setDateEndYear(newDateEndYearList)
                                    }}  
                                />
                            }
                        </div>
                    </div>                        
                </div>
            </div>

            <div className="form-group row">
                <label htmlFor={`description${props.index}`} className="col-sm-3 col-form-label">Обязанности</label>
                <div className="col-sm-9">
                    <textarea 
                        value={props.descriptionList[props.index]}
                        cols="40" 
                        rows="5"
                        onChange={e=>{
                            let newDescriptionList = Object.assign([,],props.descriptionList);
                            newDescriptionList[props.index] = e.target.value;
                            props.setDescriptionList(newDescriptionList)
                        }}
                        className="form-control" 
                        id={`description${props.index}`}
                        placeholder="Обязанности" 
                        maxLength="4000" 
                        ref={descriptionRef}
                    />
                        {
                          !isDescriptionValidate &&
                          <small className="text-danger">Обязательное поле</small> 
                        }  
                </div>
            </div>

            <div className="resume-experience-line">
                <div className="resume-experience-line-close" onClick={()=>{
                    props.deleteResumeExperience(props.index);
                }}>X</div>
            </div>
        </div>
    </Fragment>
  );
});

export default ResumeExperience;