import React from "react";
import ChannelMessage, { Mention } from "../ChannelMessage";
import { Container, Messages, InputWrapper, Input, InputIcon } from "./style";

const ChannelData: React.FC = () => {
  const messagesRef = React.useRef() as React.MutableRefObject<HTMLDivElement>;

  React.useEffect(() => {
    const div = messagesRef.current;

    if (div){
      div.scrollTop = div.scrollHeight;
    }

  }, [messagesRef]);

  return (
  <Container>
    <Messages ref={messagesRef}>
      {Array.from(Array(25).keys()).map((i) => (
        <ChannelMessage 
          key={i}
          author="Fernando Villa" 
          date="24/02/2022" 
          content="Hoje é meu aniverssário!!!" />
      ))}

      <ChannelMessage author="Diego Fernandez" date="24/02/2022" hasMention isBot content={
      <>
        <Mention>@Fernando Villa</Mention>, me carrega no LOL e CS de novo...
      </>} />
    </Messages>
    <InputWrapper>
      <Input type="text" placeholder="Conversar com #chat-livre" />
      <InputIcon />
    </InputWrapper>
  </Container>)
}

export default ChannelData;
