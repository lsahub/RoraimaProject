import React from 'react';
import { NavLink, Link } from 'react-router-dom';

const Footer = () => {
  return ( 
    <React.Fragment>
      <footer className="pt-4 my-md-5 pt-md-5 border-top">
          <div className="row">
            <div className="col-12 col-md">
              <img className="mb-2" src="https://getbootstrap.com/docs/4.0/assets/brand/bootstrap-solid.svg" alt="" width={24} height={24} />
              <small className="d-block mb-3 text-muted">© 2020 Группа компаний HeadHunter</small>
            </div>
            <div className="col-6 col-md">
              <h5>HeadHunter</h5>
              <ul className="list-unstyled text-small">
                <li><a className="text-muted" href="#">О компании</a></li>
                <li><a className="text-muted" href="#">Наши вакансии</a></li>
                <li><a className="text-muted" href="#">Реклама на сайте</a></li>
                <li><a className="text-muted" href="#">Требования к ПО</a></li>
                <li><a className="text-muted" href="#">Защита персональных данных</a></li>
                <li><a className="text-muted" href="#">Безопасный HeadHunter</a></li>
              </ul>
            </div>
            <div className="col-6 col-md">
              <h5>Сервисы для соискателей</h5>
              <ul className="list-unstyled text-small">
                <li><a className="text-muted" href="#">Готовое резюме</a></li>
                <li><a className="text-muted" href="#">Продвижение резюме</a></li>
                <li><a className="text-muted" href="#">Профориентация</a></li>
                <li><a className="text-muted" href="#">Карьерный консультант</a></li>
              </ul>
            </div>
            <div className="col-6 col-md">
              <h5>Новости и статьи</h5>
              <ul className="list-unstyled text-small">
                <li><a className="text-muted" href="#">Новости рынка HR</a></li>
                <li><a className="text-muted" href="#">Жизнь в компании</a></li>
                <li><a className="text-muted" href="#">ИТ-проекты</a></li>
              </ul>
            </div>
          </div>
        </footer>
      
    </React.Fragment>

  );
};

export default Footer;
