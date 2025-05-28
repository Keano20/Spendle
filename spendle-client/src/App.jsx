import { useEffect, useState } from 'react';

function App() {
    const [message, setMessage] = useState('Loading...');

    useEffect(() => {
        fetch('/api/status')
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Error: ${response.status}`);
                }
                return response.text(); // if backend returns plain text
            })
            .then(data => setMessage(data))
            .catch(error => setMessage(error.toString()));
    }, []);

    return (
        <div style={{ padding: '2rem', fontFamily: 'sans-serif' }}>
            <h1>Spendle Frontend</h1>
            <p>API Response: {message}</p>
        </div>
    );
}

export default App;