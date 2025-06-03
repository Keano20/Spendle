import React from 'react';
import Header from '../components/Header';
import {Outlet} from "react-router-dom";

function MainLayout({ children }) {
    return (
        <div style={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
            <Header />
            <main>
                <Outlet />
            </main>
            
        </div>
    );
}

export default MainLayout;