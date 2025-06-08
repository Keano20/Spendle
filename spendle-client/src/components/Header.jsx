import React from 'react';
import { Link } from 'react-router-dom';

function Header() {
    return (
        <header className="bg-gray-800 text-white p-4 shadow-md">
            <nav className="flex justify-between items-center">
                <h1 className="text-2xl font-semibold">Spendle</h1>
                <div className="space-x-4">
                    <Link to="/login" className="hover:text-yellow-300">Login</Link>
                    <Link to="/register" className="hover:text-yellow-300">Register</Link>
                </div>
            </nav>
        </header>
    );
}

export default Header;