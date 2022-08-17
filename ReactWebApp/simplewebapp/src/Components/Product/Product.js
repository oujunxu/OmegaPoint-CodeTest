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
                {data.map((sPro)=>
                <tbody key={sPro.title}>
                  <tr className="product-list-table-row">
                    <td className="product-list-images">
                        <img className="product-img" src={sPro.image} />
                    </td>
                    <td>
                      <div className="product-list-text-wrap">
                        <div>
                          <span>Title:</span> <br /> {sPro.title}
                        </div>
                        <div>
                          <span>Price:</span> <br /> ${sPro.price}
                        </div>
                        <div>
                          <span>Description:</span> <br /> {sPro.description}
                        </div>
                        <div>
                          <span>Category:</span> <br /> {sPro.category}
                        </div>
                        <div>
                          <span>Rate:</span> <br /> {sPro.rate}
                        </div>
                        <div>
                          <span>Count:</span> <br /> {sPro.count}
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

export default Product;