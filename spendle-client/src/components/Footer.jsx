function Footer() {
    return (
        <footer style={{
            backgroundColor: '#17B890',
            padding: '1rem',
            textAlign: 'center',
            fontSize: '0.9rem',
            color: '#555',
            marginTop: 'auto'
        }}>
            <p>© {new Date().getFullYear()} Spendle. All rights reserved.</p>
        </footer>
    );
}

export default Footer;