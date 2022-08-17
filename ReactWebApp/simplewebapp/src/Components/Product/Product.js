import React, {useEffect, useState} from "react";
import useFetch from 'react-fetch-hook';
import {useLocation, useParams} from 'react-router-dom';

function Product(props){
        let location = useLocation();
        let productID = props.match.params.id;
    
        const{ isLoading, error, data } = useFetch("http://localhost:5000/api/product/"+ parseInt(productID));
        
        if(isLoading) return "Loading..";

        if (error) return "Error!";

    
        return (
          <div className="product-wrapper text-white fixed-background">
              <table>
                {data.map(sPro =>
                <tbody key={sPro.Title}>
                  <tr className="product-list-table-row">
                    <td className="product-list-images">
                        <img className="product-img" src={sPro.Image} />
                    </td>
                    <td>
                      <div className="product-list-text-wrap">
                        <div>
                          <span>Title:</span> <br /> {sPro.Title}
                        </div>
                        <div>
                          <span>Price:</span> <br /> ${sPro.Price}
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

export default Product;