import React from 'react';
import StatusCheck from "../components/statusCheck/StatusCheck.jsx"; // For checking backend API connection status

function HomePage() {
    return (
        <div className="min-h-screen flex items-center justify-center bg-gradient-to-br from-purple-100 to-blue-100">
            <h1 className="text-5xl font-bold text-blue-900">Home</h1>
        </div>
    );
}

export default HomePage;