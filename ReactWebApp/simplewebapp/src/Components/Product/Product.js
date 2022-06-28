import React, {useEffect, useState} from "react";
import useFetch from 'react-fetch-hook';
import {useLocation, useParams} from 'react-router-dom';

function Product(){
        let location = useLocation();
        let {productID} = location.state;
    
        const{ isLoading, error, data } = useFetch("http://localhost:5000/api/product/"+ parseInt(productID));
        
        if(isLoading) return "Loading..";

        if (error) return "Error!";
    
        return (
          <div className="product-wrapper text-white fixed-background">
              <table>
                <tbody key={data.title}>
                  <tr className="product-list-table-row">
                    <td className="product-list-images">
                        <img className="product-img" src={data.image} />
                    </td>
                    <td>
                      <div className="product-list-text-wrap">
                        <div>
                          <span>Title:</span> <br /> {data.title}
                        </div>
                        <div>
                          <span>Price:</span> <br /> ${data.price}
                        </div>
                        <div>
                          <span>Description:</span> <br /> {data.description}
                        </div>
                        <div>
                          <span>Category:</span> <br /> {data.category}
                        </div>
                        <div>
                          <span>Rate:</span> <br /> {data.rating.rate}
                        </div>
                        <div>
                          <span>Count:</span> <br /> {data.rating.count}
                        </div>
                      </div>
                    </td>
                  </tr>
                  <br />
                </tbody>
              </table>
          </div>
        );
}

export default Product;