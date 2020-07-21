import React from 'react';

const Resume = () => {
  return (
    <React.Fragment>

          <form>
            <div className="card">
              <div className="card-body">
                <h1 className="card-title pricing-card-title">Липовкин Сергей Александрович</h1>
                  <div className="form-group row">
                    <label htmlFor="inputTitle" className="col-sm-2 col-form-label">Желаемая должность</label>
                    <div className="col-sm-10">
                      <input className="form-control" id="inputTitle" placeholder="Желаемая должность" maxLength="500" />
                    </div>
                  </div>

                  <div className="form-group row">
                    <label htmlFor="inputLastName" className="col-sm-2 col-form-label">Фамилия</label>
                    <div className="col-sm-10">
                      <input className="form-control" id="inputLastName" placeholder="Фамилия" maxLength="100" />
                    </div>
                  </div>
                  <div className="form-group row">
                    <label htmlFor="inputFirstName" className="col-sm-2 col-form-label">Имя</label>
                    <div className="col-sm-10">
                      <input className="form-control" id="inputFirstName" placeholder="Имя" maxLength="100" />
                    </div>
                  </div>
                  <div className="form-group row">
                    <label htmlFor="inputMiddleName" className="col-sm-2 col-form-label">Отчество</label>
                    <div className="col-sm-10">
                      <input className="form-control" id="inputMiddleName" placeholder="Отчество" maxLength="100" />
                    </div>
                  </div>
                  <div>

                  <div className="custom-control custom-radio">
                        <input type="radio" id="customRadio1" name="customRadio" className="custom-control-input" />
                        <label className="custom-control-label" htmlFor="customRadio1">Toggle this custom radio</label>
                      </div>
                      <div className="custom-control custom-radio">
                        <input type="radio" id="customRadio2" name="customRadio" className="custom-control-input" />
                        <label className="custom-control-label" htmlFor="customRadio2">Or toggle this other custom radio</label>
                      </div>
                    </div>
                <button type="button" className="btn btn-lg btn-outline-primary">Сохранить</button>
              </div>
            </div>


          </form>
    </React.Fragment>


  );
};

export default Resume;  