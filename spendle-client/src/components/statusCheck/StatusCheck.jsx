import { useEffect, useState } from 'react';

function StatusCheck() {
    const [message, setMessage] = useState('Loading...');

    useEffect(() => {
        fetch('/api/status')
            .then((response) => {
                if (!response.ok) throw new Error(`Error: ${response.status}`);
                return response.text();
            })
            .then((data) => setMessage(data))
            .catch((err) => setMessage(err.toString()));
    }, []);

    return (
        <div>
            <p>API Response: {message}</p>
        </div>
    );
}

export default StatusCheck;