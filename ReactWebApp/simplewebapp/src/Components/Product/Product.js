import React, {Component} from "react";
import {Link} from 'react-router-dom';

export default class Product extends Component {

    constructor(props) {
        super(props);
        this.state = { product: [] };

      }
    
      refreshList() {
        fetch("http://localhost:5000/api/product/"+this.props.ProductId)
          .then((response) => response.json())
          .then((data) => {
            this.setState({ product: data });
          });
      }
    
      componentDidMount() {
        this.refreshList();
      }
    
      componentDidUpdate() {
        this.refreshList();
      }

    render(){
        const {product} = this.state;
        return (
          <div className="product-wrapper">
              <table>
                {product.map(sPro =>
                <tbody key={product.Title}>
                  <tr className="product-list-table-row">
                    <td className="product-list-images">
                      <Link to={"/product/" + sPro.id}>
                        <img className="product-img" src={sPro.Image} />
                      </Link>
                    </td>
                    <td>
                      <div className="product-list-text-wrap">
                        <div>
                          <span>Title:</span> <br /> {sPro.Title}
                        </div>
                        <div>
                          <span>Price:</span> <br /> {sPro.Price}
                        </div>
                        <div>
                          <span>Description:</span> <br /> {sPro.Description}
                        </div>
                        <div>
                          <span>Category:</span> <br /> {sPro.Category}
                        </div>
                        <div>
                          <span>Rate:</span> <br /> {sPro.Rate}
                        </div>
                        <div>
                          <span>Count:</span> <br /> {sPro.Count}
                        </div>
                      </div>
                    </td>
                  </tr>
                  <br />
                </tbody>
                )}
              </table>
           
          </div>
        );
    }
}