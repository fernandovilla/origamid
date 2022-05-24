import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { login } from './store/login';



const App = () => {

  const [username, setUsername] = React.useState('dog');
  const [password, setPassword] = React.useState('dog');
  
  const dispatch = useDispatch();

  const onChangeUsername = ({target}) => setUsername(target.value);
  const onChangePassword = ({target}) => setPassword(target.value);

  const {data} = useSelector(state => state.login.user);

  console.log(data);

  const handleSubmit = (event) => {
    event.preventDefault();

    //dispatch(fetchToken({ username, password}));
    dispatch(login({ username, password }));
  }

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <label htmlFor="username" style={{display:'block'}}>Username:</label>
        <input id="username" type="text" value={username} onChange={onChangeUsername} />        

        <label htmlFor="password" style={{display:'block'}}>Password:</label>
        <input id="password" type="password" value={password} onChange={onChangePassword} />

        <button style={{display: 'block', marginTop: '10px'}} >Login</button>

        <p>{data && 'Email: ' + data.email}</p>
        
      </form>
    </div>
  );
}

export default App;
