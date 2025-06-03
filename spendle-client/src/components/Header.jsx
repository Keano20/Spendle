import React from 'react';
import { Link } from 'react-router-dom';

function Header() {
    return (
        <header style={styles.header}>
            <h1 style={styles.logo}>Spendle</h1>
            <nav style={styles.nav}>
                <Link to="/" style={styles.link}>Home</Link>
                <Link to="/login" style={styles.link}>Login</Link>
                <Link to="/register" style={styles.link}>Register</Link>
            </nav>
        </header>
    );
}

const styles = {
    header: {
        display: 'flex',
        justifyContent: 'space-between',
        alignItems: 'center',
        padding: '1rem 2rem',
        backgroundColor: '#f4f4f4',
        borderBottom: '1px solid #ddd',
    },
    logo: {
        margin: 0,
        fontSize: '1.5rem',
        color: '#333',
    },
    nav: {
        display: 'flex',
        gap: '1rem',
    },
    link: {
        textDecoration: 'none',
        color: '#0077cc',
        fontWeight: '500',
    }
};

export default Header;