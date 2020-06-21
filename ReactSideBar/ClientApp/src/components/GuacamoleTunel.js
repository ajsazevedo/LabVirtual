import Guacamole from "guacamole-common-js";
import React, { Component } from "react";

this.guacaRef.current = new Guacamole.Client(new Guacamole.WebSocketTunnel(webSocketFullUrl));
this.guacaRef.current.onerror = function (error) {
  alert(error);
};
this.guacaRef.current.connect();

// Disconnect on close
window.onunload = function () {
  this.guacaRef.current.disconnect();
}

var webSocketFullUrl = "";

this.displayRef.current.appendChild(this.guacaRef.current.getDisplay().getElement());

export default class GuacamoleTunel extends Component {
  constructor(props) {
    super(props);
    this.displayRef = React.createRef();
    this.guacaRef = React.createRef();
  }

  render() {
    return (<div ref={displayRef} />);
  }

}

