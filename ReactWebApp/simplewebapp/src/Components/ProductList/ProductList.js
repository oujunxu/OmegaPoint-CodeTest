import React, {Component} from 'react';
import { Link, Route, Switch } from 'react-router-dom';
import Product from './../Product/Product';

export default class ProductList extends Component {
  constructor(props) {
    super(props);
    this.state = { products: [] };
  }

  refreshList() {
    fetch("http://localhost:5000/api/product/")
      .then((response) => response.json())
      .then((data) => {
        this.setState({ products: data });
      });

  }

  componentDidMount() {
    this.refreshList();
  }

  componentDidUpdate() {
    this.refreshList();
  }


  render() {
    const { products } = this.state;
    return (
      <div className="list-wrapper fixed-background" style={{backgroundImage: 'url("https://virtuoart.com/public/uploads/preview/abbca3e3a8329cd0ea6515d12f807a1c-61861588150306juuydyjldi.jpg")'}}>
        <table className="product-list-table">
          {products.map((product) => (
            <tbody key={product.Title}>
              <tr className="product-list-table-row">
                <td className="product-list-images">
                  <Link to={{pathname:"/Product", state: {productID: product.Id}}}><img className="product-img"  src={product.Image}/></Link>
                </td>
                <td>
                    <div className="product-list-text-wrap text-white">
                      <span>Title:</span>
                      <br/>
                      {product.Title}
                      <br />
                      <span>Price:</span>
                      <br/>
                      {product.Price}
                    </div>
                </td>
              </tr>
              <br />
            </tbody>
          ))}
        </table>
      </div>
    );
  }
}