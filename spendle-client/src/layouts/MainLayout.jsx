import React from 'react';
import Header from '../components/Header';
import {Outlet} from "react-router-dom";
import Footer from "../components/Footer.jsx";

function MainLayout({ children }) {
    return (
        <div style={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
            <Header />
            <main>
                <Outlet />
            </main>
            <Footer />
        </div>
    );
}

export default MainLayout;