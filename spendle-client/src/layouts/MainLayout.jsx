import React from 'react';
import Header from '../components/Header';
import {Outlet} from "react-router-dom";
import Footer from "../components/Footer.jsx";

function MainLayout({ children }) {
    return (
        <div className="min-h-screen flex flex-col">
            <Header />
            <main className="flex-grow p-4">
                <Outlet />
            </main>
            <Footer />
        </div>
    );
}

export default MainLayout;