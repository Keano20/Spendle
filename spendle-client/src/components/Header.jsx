import { Link } from 'react-router-dom';

function Header() {
    return (
        <header className="text-[#363635] shadow-md px-6 py-4">
            <div className="max-w-7xl mx-auto flex items-center justify-between">
                <h1 className="text-2xl font-bold text-[#363635] tracking-wide">Spendle</h1>
                <nav className="flex gap-6">
                    <Link to="/" className="hover:text-[#363635] transition-colors">Home</Link>
                    <Link to="/login" className="hover:text-[##363635] transition-colors">Login</Link>
                    <Link to="/register" className="hover:text-[##363635] transition-colors">Register</Link>
                </nav>
            </div>
        </header>
    );
}

export default Header;