function Footer() {
    return (
        <footer style={{
            backgroundColor: '#f2f2f2',
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