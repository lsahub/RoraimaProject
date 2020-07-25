import React from 'react';
import Advertising from 'containers/advertising';
import { useSelector } from 'react-redux';
const Fragment = React.Fragment; 


const Completed = (props) => {

  const savedResume = useSelector(state => state.resume.savedResume.resume );
 

  return (
    <Fragment>
      <div className="page-resume">
          <div className="card">
            <div className="card-body">
              <div className='form-group row'>
                <div className="col-sm-8 media-order-2">
                  {
                    savedResume != null &&
                    <h1 className="card-title pricing-card-title">Ваше резюме отправлено в базу</h1>
                  }
                  {
                    savedResume == null &&
                    <h1 className="card-title pricing-card-title">Ошибка, резюме не отправлено</h1>
                  }
                </div>
                <Advertising />
              </div>
            </div>
          </div>
 
      </div>
    
    </Fragment>


  );
};

export default Completed;