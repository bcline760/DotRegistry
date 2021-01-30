import { Entity } from "./entity.model";

export interface Provider extends Entity {
  /**
   * The ID of this provider
   */
  id: string;

  /**
  * Get how many times this provider has been installed
  */
  installCount: number;

  /**
  * The date the last time this provider was published
  */
  lastPublished: Date;

  /**
  * The name of the provider
  */
  name: string;

  /**
  * The namespace of the provider, usually the name of the repository
  */
  namespace: string;

  /**
  * Terraform protocols supported by this provider
  */
  protocols: string[];

  /**
  * The latest version of this provider
  */
  version: string;

  /**
  * The last user who published the provider
  */
  publishedBySlug: string;

  /**
  * Any tags associated with provider
  */
  tags?: string
}
